<template>
  <q-card style="height:min-content">
    <div class="card-header weight-3" :class="props.data.status">
      <div class="row">
        <q-icon size="24px" v-if="props.data.status == 'alarm' || props.data.status == 'warning'"
          :class="props.data.status == 'alarm' ? 'text-accent' : props.data.status == 'warning' ? 'warning2' : ''"
          :name="props.data.status == 'alarm' || props.data.status == 'warning' ? 'warning' : ''"></q-icon>
        <div class="exhghauster_name" style="padding-left: 10px">
          {{ props.data.name }}
        </div>
      </div>
      <div class="row">
        <button icon="arrow_forward" @click="router.push({ path: `trends/${props.data.id}` })"
          class="card-link-btn shadow-1">
          <q-icon size="20px" name="query_stats" />
        </button>
        <button icon="arrow_forward" @click="router.push({ path: `exhauster/${props.data.id}` })"
          class="card-link-btn shadow-1 arrow_forward_btn">
          <q-icon size="26px" name="chevron_right" rounded color="black" />
        </button>
      </div>
    </div>
    <div class="card-main">
      <div class="q-mb-sm">
        <div class="row justify-between items-center">
          <div class="weight-2 q-mr-xs">
            {{ props.data.rotor_name }}
          </div>
          <div>
            <q-chip
              style="background-color: #F4F4F4;border-radius: 4px;padding:0 4px 0 4px">{{ moment(props.data.rotor_change_date).format("D.MM.YYYY") }}</q-chip>
          </div>
        </div>
        <div class="weight-2 row justify-between q-py-sm">
          <div>
            Актуальность на:
          </div>
          <span>{{ formatDate(props.data?.sensors_payload?.bearings[0]?.signal_values[0]?.batch_time) }}</span>
        </div>
      </div>
      <div class="weight-1 q-py-sm"
        style="border-top: 1px solid rgb(220,220,220);border-bottom: 1px solid rgb(220,220,220);">
        <div class="weight-3 q-mb-sm q-mx-md">Последняя замена ротора</div>
        <div class="row rounded-borders" style="background-color: #FAFAFA;">
          <div style="width:30px"></div>
          <q-chip class="date-chip weight-3">
            {{ Math.ceil(((new Date()) - (new Date(props.data.rotor_change_date))) / 86400000) }} сут
          </q-chip>
          <div style="opacity:0.7;font-size: 12px;" class="column q-ml-sm items-center justify-center">
            <div>Прогноз</div>
            <div class="weight-3">> 5 сут</div>
          </div>
        </div>
      </div>
      <q-space />
      <q-img src="~assets/scheme-rotor.svg" class="rotor-img" />
      <q-expansion-item header-class="card-expansion-item weight-3" dense label="Предупреждение" style="padding-top:10px">
        <q-list style="font-size: 13px !important;">
          <q-item v-for="st in otherStatus" :key="st.name" :class="st.status"
            class="row justify-between rounded-borders q-pa-none q-px-sm q-my-xs q-ml-sm">
            <q-item-section class="q-my-none">
              {{ st.name }}
            </q-item-section>
            <q-item-section class="items-end q-my-none">
              <q-chip class="damage-chip" :class="st.status + '-chip'" :icon="st.icon"></q-chip>
            </q-item-section>
          </q-item>
        </q-list>
      </q-expansion-item>
      <q-expansion-item header-class="card-expansion-item weight-3" dense label="Все подшипники">
        <q-list v-for="bearing in bearingStatus" :key="bearing.name" style="font-size: 13px !important;">
          <q-item :class="bearing.overall" class="row justify-between rounded-borders q-pa-none q-px-sm q-mb-xs q-ml-sm">
            <q-item-section class="q-my-none">
              {{ bearing.name }}
            </q-item-section>
            <q-item-section class="items-end q-my-none">
              <div class="row">
                <q-chip v-if="bearing.temperature !== 'ok'" :class="bearing.temperature + '-chip'" class="damage-chip"
                  icon="thermostat"></q-chip>
                <q-chip v-if="bearing.vibration !== 'ok' && !!bearing.vibration" :class="bearing.vibration + '-chip'"
                  class="damage-chip" icon="sensors"></q-chip>
              </div>
            </q-item-section>
          </q-item>
        </q-list>
      </q-expansion-item>
    </div>
  </q-card>
</template>
<script setup>
import { defineProps, ref, onMounted, watch, onUpdated } from 'vue'
import { useRouter } from 'vue-router';
import { date } from 'quasar'
import moment from 'moment'

const bearingStatus = ref([])
const otherStatus = ref([])
const router = useRouter()
const props = defineProps({
  data: Object,
})

onUpdated(() => {
  bearingStatus.value = proccessBearings()
  otherStatus.value = proccessOtherSignals()
})
onMounted(() => {
  bearingStatus.value = proccessBearings()
  otherStatus.value = proccessOtherSignals()
})


function proccessOtherSignals() {
  const map = []
  props.data.sensors_payload.other_senors.forEach((v) => {
    if (v.device_kind.name === 'Маслосистема') {
      v.signal_values.forEach(s => {
        if (s.signal_kind_code === 'oil_level') {
          map.push({ status: s.status, icon: 'opacity', name: v.device_kind.name })
        }
        if (s.signal_kind_code === 'oil_pressure') {
          map.push({ status: s.status, icon: 'compress', name: v.device_kind.name })
        }
      })
    }
    if (v.device_kind.name === 'Газовый коллектор') {
      map.push({ status: v.signal_values.find(g => g.signal_kind_code === 'temperature_before')?.status, icon: 'thermostat', name: v.device_kind.name })
      map.push({ status: v.signal_values.find(g => g.signal_kind_code === 'underpressure_before')?.status, icon: 'compress', name: v.device_kind.name })
    }
    if (v.device_kind.name === 'Охладитель') {
      if (v.signal_values.some(g => g.status !== 'ok')) {
        map.push({ status: v.signal_values.find(g => g.status === 'warning' || g.status === 'alarm')?.status, icon: 'thermostat', name: v.device_kind.name })
      } else {
        map.push({ status: 'ok', icon: 'thermostat', name: v.device_kind.name })
      }
    }
  })
  return map.filter(m => m.status != 'ok')
}
function formatDate(timeStamp) {
  return date.formatDate(timeStamp, 'DD-MM-YYYY HH:mm:ss')
}

function proccessBearings() {
  const bearings = []
  props.data.sensors_payload.bearings.forEach((b, i) => {
    bearings.push({ name: b.device_kind.name, overall: 'ok', temperature: 'ok', vibration: 'ok' })
    b.signal_values.forEach((v) => {
      if (v.signal_kind_code === 'vibration_horizontal' || v.signal_kind_code === 'vibration_vertical' || v.signal_kind_code === 'vibration_axial') {
        if (v.status === 'alarm') {
          bearings[i].vibration = v.status
        } else if (v.status === 'warning' && bearings[i].vibration !== 'alarm') {
          bearings[i].vibration = v.status
        }
      }
      if (v.signal_kind_code === "temperature") {
        bearings[i].temperature = v.status
      }
    })
    if (bearings[i].vibration === 'alarm' || bearings[i].temperature === 'alarm') {
      bearings[i].overall = 'alarm'
    } else if (bearings[i].vibration === 'warning' || bearings[i].temperature === 'warning') {
      bearings[i].overall = 'warning'
    }
  })
  return bearings
}
watch(props.data, () => {
  console.log(1)
})
</script>
<style lang="scss" scoped>
.card-header {
  width: 350px;
  height: 40px;
  font-size: 15px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 14px 0 14px;
  font-weight: 600;
  background-color: v-bind(headerBgColor);



  & :first-child {
    margin-right: 4px;
  }
}

.warning2 {
  color: $warning-accent;
}

.card-main {
  padding: 10px 15px 20px 12px;

  .date-chip {
    background-color: #F4F4F4;
    border-radius: 4px;
    margin: 10px 0 10px 0;
    font-size: 12px;
  }

  .card-expansion {
    padding: 0
  }
}

.damage-chip {
  width: min-content;
  height: min-content;
  padding: 5px 3px 5px 11px;
  margin: 0;
  margin-left: 2px;
  border-radius: 6px;
  border: 1px solid;
}

.alarm {
  background-color: $danger;
}

.ok {
  background-color: $positive;
  color: white;
}

.warning {
  background-color: $warning;
}

.alarm-chip {
  background-color: #FCDBCB;
  border: 1px solid $accent;
  color: $accent;
}

.warning-chip {
  background-color: #FEF1DB;
  border: 1px solid $warning-accent;
  color: $warning-accent !important;
}
</style>

<style lang="scss">
.card-link-btn {
  padding: 0;
  height: 26px;
  width: 26px;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #FAFAFA;
  border: 1px solid #EAEAEA;
  border-radius: 4px;

  & :hover {
    cursor: pointer;
  }
}

.q-chip__icon {
  color: inherit
}

.q-item {
  min-height: 32px;
}

.card-expansion-item {
  padding: 0 2px 0 2px;
  justify-content: space-between !important;
}

.arrow_forward_btn {
  align-items: flex-start;
  padding: 0px;
}

.exhghauster_name {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0px;
  gap: 10px;
  width: 214px;
  height: 24px;
}

.rotor-img {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  gap: 10px;
  background: #EFF2F6;
  border: 0.5px solid #CED7E7;
  border-radius: 6px;
  flex: none;
  order: 3;
  flex-grow: 0;
}
</style>
