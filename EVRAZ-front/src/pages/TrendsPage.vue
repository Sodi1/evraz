<template>
  <div>
    <ApexArea :charts="charts" :predictedChart="predictedChart" :names="Nnames" />
  </div>
  <q-drawer show-if-above bordered>
    <div class="q-px-md q-py-sm weight-2" style="font-size: 24px;border-bottom: 1px solid grey;">{{ name }}</div>
    <q-expansion-item expand-separator label="Подшипники" default-opened>
      <q-expansion-item v-for="bearing in sideMenuData?.bearings" :key="bearing.device_kind.name" expand-separator
        :label="bearing.device_kind.name" :header-inset-level="0.15">
        <q-list style="margin-left: 26px;" v-for="signal in bearing.signal_values" :key="signal.id">
          <q-item @click="checkSignalId(signal.signal_kind_id)" clickable v-ripple class="ite">
            <q-item-section :class="{ 'selected': ids.has(signal.signal_kind_id) }">
              <div class="row justify-between q-px-xs full-width">
                <div>{{ signal.signal_kind_short_name }}, {{ signal.signal_kind_dimension }}</div>
                <div :class="signal.status">{{ signal.value.toFixed(3) }}</div>
              </div>
            </q-item-section>
          </q-item>
        </q-list>
      </q-expansion-item>
    </q-expansion-item>
    <q-expansion-item expand-separator label="Прочие" default-opened>
      <q-expansion-item v-for="device in sideMenuData?.other_senors" :key="device.device_kind.name" expand-separator
        :label="device.device_kind.name" :header-inset-level="0.15">
        <q-list style="margin-left: 26px;" v-for="signal in device.signal_values" :key="signal.id">
          <q-item @click="checkSignalId(signal.signal_kind_id)" clickable v-ripple class="ite">
            <q-item-section :class="{ 'selected': ids.has(signal.signal_kind_id) }">
              <div class="row justify-between q-px-xs full-width">
                <div>{{ signal.signal_kind_short_name }}, {{ signal.signal_kind_dimension }}</div>
                <div :class="signal.status">{{ signal.value.toFixed(3) }}</div>
              </div>
            </q-item-section>
          </q-item>
        </q-list>
      </q-expansion-item>
    </q-expansion-item>
  </q-drawer>
</template>
<script setup>
import { defineAsyncComponent, onMounted, ref } from 'vue'
import AspiratorService from 'src/services/AspiratorService';
import ChartsService from 'src/services/ChartsService';
import { useRoute } from 'vue-router'
import PredictService from "../services/predictService"

const ApexArea = defineAsyncComponent(() =>
  import('src/components/charts/ChartAreaComponent.vue')
)
const route = useRoute()
const sideMenuData = ref()
const ids = ref(new Set())
const charts = ref([])
const Nnames = ref([])
const predictedChart = ref([])
async function checkSignalId(id) {
  if (ids.value.has(id)) {
    ids.value.delete(id)
  } else {
    ids.value.add(id)
  }
  charts.value = await ChartsService.getCharts(Array.from(ids.value))
  if (ids.value.size == 1) {
    predictedChart.value = (await PredictService.predict(Array.from(ids.value)[0])).data.data
  } else {
    predictedChart.value = null
  }
  let names = []
  ids.value.forEach(id => {
    sideMenuData.value.bearings.forEach((v) => {
      v.signal_values.forEach((f) => {
        if (id === f.signal_kind_id) {
          names.push(v.device_kind.name + ' ' + f.signal_kind_short_name + ' ' + f.signal_kind_dimension)
        }
      })
    })
    sideMenuData.value.other_senors.forEach((v) => {
      v.signal_values.forEach((f) => {
        if (id === f.signal_kind_id) {
          names.push(v.device_kind.name + ' ' + f.signal_kind_short_name + ' ' + f.signal_kind_dimension)
        }
      })
    })
  })
  Nnames.value = names
}
const name = ref('')
onMounted(async () => {
  sideMenuData.value = (await AspiratorService.getAspirator(route.params.id)).data.aspirator
  name.value = sideMenuData.value.name
  sideMenuData.value = sideMenuData.value.sensors_payload
})

</script>
<style lang="scss" scoped>
.ite {
  margin: 2px 0 2px 0;
}

.warning {
  background-color: $warning;
}

.alarm {
  background-color: $danger;
}

.ok {
  background-color: inherit;
}

.selected {
  border-radius: 4px;
  border: 1px solid $info;
}
</style>
