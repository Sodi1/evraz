<template>
  <div style="position: relative;">
    <div style="position: absolute;left:1.2%;top:3.2%;font-size: 24px;" class="weight-3">
      {{ aspirator?.data?.aspirator?.name }}
    </div>
    <div style="left:49.6%;top:16%;width:10.19%" class="exgauster-scheme-text">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(oilLevel?.batch_time) }}</strong>
      </q-tooltip>
      <q-linear-progress v-if="oilLevel?.value" dark size="10px" :value="oilLevel?.value / 100"
        :color="this.toColor(oilLevel?.status)" class="grey" />
      <q-linear-progress v-else dark size="10px" :value="1" color="red" class="grey" />

    </div>

    <div style="left:74.7%;top:30.3%;width: 11.8%" class="exgauster-scheme-text">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(oilPressure?.batch_time) }}</strong>
      </q-tooltip>
      <q-linear-progress v-if="oilPressure?.value" dark size="10px" :value="oilPressure?.value / 6.0"
        :color="this.toColor(oilPressure?.status)" class="grey" />
      <q-linear-progress v-else dark size="10px" :value="1" color="red" class="grey" />
    </div>


    <div style="left:70.85%;top:3.87%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(waterAfterCoolerTemp?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(waterAfterCoolerTemp?.batch_time) }}</strong>
      </q-tooltip>
      {{ waterAfterCoolerTemp?.value?.toFixed(2) }} °C
    </div>

    <div style="left:66.9%;top:3.87%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(waterBeforeCoolerTemp?.status)]">
      {{ waterBeforeCoolerTemp?.value?.toFixed(2) }} °C
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(waterBeforeCoolerTemp?.batch_time) }}</strong>
      </q-tooltip>
    </div>
    <div style="left:62.45%;top:15.87%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(coolerBeforeTemp?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(coolerBeforeTemp?.batch_time) }}</strong>
      </q-tooltip>
      {{ coolerBeforeTemp?.value?.toFixed(2) }} °C
    </div>
    <div style="left:69.1%;top:25.7%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(coolerAfterTemp?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(coolerAfterTemp?.batch_time) }}</strong>
      </q-tooltip>
      {{ coolerAfterTemp?.value?.toFixed(2) }} °C
    </div>


    <div style="left:71.65%;top:43.6%;" class="exgauster-scheme-text" :class="[this.toColorClass(rotorCurrent?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(rotorCurrent?.batch_time) }}</strong>
      </q-tooltip>
      {{ rotorCurrent?.value?.toFixed(2) }}
    </div>
    <div style="left:71.65%;top:46.6%;" class="exgauster-scheme-text" :class="[this.toColorClass(statorCurrent?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(statorCurrent?.batch_time) }}</strong>
      </q-tooltip>
      {{ statorCurrent?.value?.toFixed(2) }}
    </div>
    <div style="left:71.65%;top:49.6%;" class="exgauster-scheme-text" :class="[this.toColorClass(rotorVoltage?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(rotorVoltage?.batch_time) }}</strong>
      </q-tooltip>
      {{ rotorVoltage?.value?.toFixed(2) }}
    </div>
    <div style="left:71.65%;top:52.6%;" class="exgauster-scheme-text" :class="[this.toColorClass(statorVoltage?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(statorVoltage?.batch_time) }}</strong>
      </q-tooltip>
      {{ statorVoltage?.value?.toFixed(2) }}
    </div>


    <div style="left:25%;top:24.3%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(temperatureBefore?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(temperatureBefore?.batch_time) }}</strong>
      </q-tooltip>
      {{ temperatureBefore?.value?.toFixed(0) }} °C
    </div>
    <div style="left:23.9%;top:28.3%;" class="exgauster-scheme-text"
      :class="[this.toColorClass(underpressureBefore?.status)]">
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(underpressureBefore?.batch_time) }}</strong>
      </q-tooltip>
      Разряжение, мм.в.ст &nbsp;{{ underpressureBefore?.value?.toFixed(1) }}
    </div>

    <div style="left:15%;top:53.8%;width:5.3%" class="row justify-center exgauster-scheme-text">
      9 ПС
    </div>
    <div style="left:15%;top:57.2%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing9Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing9Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing9Temp?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:15%;top:66.3%;width:5.3%" class="row justify-center exgauster-scheme-text">
      8 ПС
    </div>
    <div style="left:15%;top:69.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing8Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing8Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing8Temp?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:15%;top:72.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing8VerVibr?.status)]">
      <div>B, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing8VerVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing8VerVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:15%;top:75.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing8HorVibr?.status)]">
      <div>Г, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing8HorVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing8HorVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:15%;top:78.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing8AxiaVibr?.status)]">
      <div>O, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing8AxiaVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing8AxiaVibr?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:39.4%;top:31.18%;width:5.3%" class="row justify-center exgauster-scheme-text">
      4 ПС
    </div>
    <div style="left:39.4%;top:34.8%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing4Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing4Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing4Temp?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:39.4%;top:68.0%;width:5.3%" class="row justify-center exgauster-scheme-text">
      6 ПС
    </div>
    <div style="left:39.5%;top:71.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing6Temp?.status)]">
      <div>B, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing6Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing6Temp?.value?.toFixed(2) }}
      </div>
    </div>

    <div style="left:39.4%;top:78.2%;width:5.3%" class="row justify-center exgauster-scheme-text">
      7 ПС
    </div>

    <div style="left:26.6%;top:88.77%;width:4.4%;" class="row justify-center exgauster-scheme-text">
      <q-linear-progress dark size="11.2px" :value="gate_valve?.value" :color="gate_valveColor" />
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(gate_valve?.batch_time) }}</strong>
      </q-tooltip>
    </div>

    <div style="left:39.5%;top:81.7%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing7Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing7Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing7Temp?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:39.5%;top:84.7%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing7VerVibr?.status)]">
      <div>B, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing7VerVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing7VerVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:39.5%;top:87.7%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing7HorVibr?.status)]">
      <div>Г, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing7HorVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing7HorVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:39.5%;top:90.7%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing7AxiaVibr?.status)]">
      <div>O, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing7AxiaVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing7AxiaVibr?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:48.1%;top:31.1%;width:5.3%" class="row justify-center exgauster-scheme-text">
      3 ПС
    </div>
    <div style="left:48.13%;top:34.8%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing3Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing3Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing3Temp?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:48.1%;top:68%;width:5.3%" class="row justify-center exgauster-scheme-text">
      5 ПС
    </div>
    <div style="left:48.2%;top:71.6%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing5Temp?.status)]">
      <div>T, °C</div>
      <div>{{ bearing5Temp?.value?.toFixed(2) }}</div>
      <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
        <strong>{{ formatDate(bearing3Temp?.batch_time) }}</strong>
      </q-tooltip>
    </div>


    <div style="left:56.4%;top:68%;width:5.3%" class="row justify-center exgauster-scheme-text">
      2 ПС
    </div>
    <div style="left:56.4%;top:71.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing2Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing2Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing2Temp?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:56.4%;top:74.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing2VerVibr?.status)]">
      <div>B, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing2VerVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing2VerVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:56.4%;top:77.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing2HorVibr?.status)]">
      <div>Г, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing2HorVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing2HorVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:56.4%;top:80.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing2AxiaVibr?.status)]">
      <div>O, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing2AxiaVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing2AxiaVibr?.value?.toFixed(2) }}
      </div>
    </div>


    <div style="left:74.2%;top:68%;width:5.3%" class="row justify-center exgauster-scheme-text">
      1 ПС
    </div>
    <div style="left:74.2%;top:71.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing1Temp?.status)]">
      <div>T, °C</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing1Temp?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing1Temp?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:74.2%;top:74.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing1VerVibr?.status)]">
      <div>B, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing1VerVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing1VerVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:74.2%;top:77.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing1HorVibr?.status)]">
      <div>Г, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing1HorVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing1HorVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <div style="left:74.2%;top:80.4%;width: 5.3%;" class="highlighted-val exgauster-scheme-text"
      :class="[this.toColorClass(bearing1AxiaVibr?.status)]">
      <div>O, мм/с</div>
      <div>
        <q-tooltip anchor="center right" self="center left" :offset="[10, 10]">
          <strong>{{ formatDate(bearing1AxiaVibr?.batch_time) }}</strong>
        </q-tooltip>
        {{ bearing1AxiaVibr?.value?.toFixed(2) }}
      </div>
    </div>
    <q-img src="~assets/exgauster-scheme.svg" />
  </div>
</template>
<script>
import { useRoute } from 'vue-router';
import useOffsetStore from "src/stores/mainStore"
import AspiratorService from "../services/AspiratorService";
import moment from 'moment'

export default {
  data: () => ({
    router: null,
    aspirator: null,
    store: useOffsetStore(),
    bearings: [],
    otherSenors: [],
    id: ''
  }),

  async mounted() {
    this.id = this.router.params["id"]
    this.aspirator = await AspiratorService.getAspirator(this.router.params["id"], this.store.offset)
    this.bearings = this.aspirator?.data?.aspirator?.sensors_payload?.bearings
    this.otherSenors = this.aspirator?.data?.aspirator?.sensors_payload?.other_senors
  },

  async created() {
    this.router = useRoute()
    setInterval(async () => {
      this.aspirator = await AspiratorService.getAspirator(this.id, this.store.offset)
      this.bearings = this.aspirator?.data?.aspirator?.sensors_payload?.bearings
      this.otherSenors = this.aspirator?.data?.aspirator?.sensors_payload?.other_senors
    }, 2000)
  },

  computed: {
    fix() {
      return this.store.offset
    },
    bearing9Temp: function () {
      return this.bearings[8]?.signal_values[0]
    },
    bearing8Temp: function () {
      return this.bearings[7]?.signal_values[3]
    },
    bearing8VerVibr: function () {
      return this.bearings[7]?.signal_values[1]
    },
    bearing8HorVibr: function () {
      return this.bearings[7]?.signal_values[0]
    },
    bearing8AxiaVibr: function () {
      return this.bearings[7]?.signal_values[0]
    },
    bearing7Temp: function () {
      return this.bearings[6]?.signal_values[3]
    },
    bearing7VerVibr: function () {
      return this.bearings[6]?.signal_values[1]
    },
    bearing7HorVibr: function () {
      return this.bearings[6]?.signal_values[0]
    },
    bearing7AxiaVibr: function () {
      return this.bearings[6]?.signal_values[0]
    },
    bearing6Temp: function () {
      return this.bearings[5]?.signal_values[0]
    },
    bearing5Temp: function () {
      return this.bearings[4]?.signal_values[0]
    },
    bearing4Temp: function () {
      return this.bearings[3]?.signal_values[0]
    },
    bearing3Temp: function () {
      return this.bearings[2]?.signal_values[0]
    },
    bearing2Temp: function () {
      return this.bearings[1]?.signal_values[3]
    },
    bearing2VerVibr: function () {
      return this.bearings[1]?.signal_values[1]
    },
    bearing2HorVibr: function () {
      return this.bearings[1]?.signal_values[0]
    },
    bearing2AxiaVibr: function () {
      return this.bearings[1]?.signal_values[0]
    },
    bearing1Temp: function () {
      return this.bearings[0]?.signal_values[3]
    },
    bearing1VerVibr: function () {
      return this.bearings[0]?.signal_values[1]
    },
    bearing1HorVibr: function () {
      return this.bearings[0]?.signal_values[0]
    },
    bearing1AxiaVibr: function () {
      return this.bearings[0]?.signal_values[0]
    },

    statorCurrent: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Главный привод")[0]?.signal_values.filter(s => s.signal_kind_code == "stator_current")[0]
    },
    rotorCurrent: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Главный привод")[0]?.signal_values.filter(s => s.signal_kind_code === "rotor_current")[0]
    },
    rotorVoltage: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Главный привод")[0]?.signal_values.filter(s => s.signal_kind_code === "rotor_voltage")[0]
    },
    statorVoltage: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Главный привод")[0]?.signal_values.filter(s => s.signal_kind_code === "stator_voltage")[0]
    },

    coolerBeforeTemp: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Охладитель")[0]?.signal_values.filter(s => s.signal_kind_code === "temperature_before")[0]
    },
    waterBeforeCoolerTemp: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Охладитель")[0]?.signal_values.filter(s => s.signal_kind_code === "temperature_before")[0]
    },
    coolerAfterTemp: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Охладитель")[0]?.signal_values.filter(s => s.signal_kind_code === "temperature_after" && s.value > 0.00)[0]
    },
    waterAfterCoolerTemp: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Охладитель")[0]?.signal_values.filter(s => s.signal_kind_code === "temperature_after" && s.value < 0.00)[0]
    },
    oilLevel: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Маслосистема")[0]?.signal_values.filter(s => s.signal_kind_code === "oil_level")[0]
    },
    oilPressure: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Маслосистема")[0]?.signal_values.filter(s => s.signal_kind_code === "oil_pressure")[0]
    },
    gate_valve: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Положение задвижки")[0]?.signal_values.filter(s => s.signal_kind_code === "gas_valve_open")[0]
    },
    gate_valveColor: function () {
      return this.toColor(this.otherSenors.filter(s => s?.device_kind?.name === "Положение задвижки")[0]?.signal_values.filter(s => s.signal_kind_code === "gas_valve_open")[0]?.status)
    },
    underpressureBefore: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Газовый коллектор")[0]?.signal_values.filter(s => s.signal_kind_code === "underpressure_before")[0]
    },
    temperatureBefore: function () {
      return this.otherSenors.filter(s => s?.device_kind?.name === "Газовый коллектор")[0]?.signal_values.filter(s => s.signal_kind_code === "temperature_before")[0]
    }
  },

  methods: {
    toColor(status) {
      if (status == null) return "FF0000";
      if (status === "ok") return "green-6";
      if (status === "alarm") return "yellow-3";
      if (status === "warning") return "red-3";
      return "yellow-3";
    },
    formatDate(timeStamp) {
      return moment(timeStamp).format('M-DD-YYYY hh:mm:ss')
    },
    toColorClass(status) {
      if (!status) return "alarm";
      return status;
    }
  },
  watch: {
    async fix(newV, old) {
      this.aspirator = await AspiratorService.getAspirator(this.router.params["id"], newV)
      this.bearings = this.aspirator?.data?.aspirator?.sensors_payload?.bearings
      this.otherSenors = this.aspirator?.data?.aspirator?.sensors_payload?.other_senors
      this.store.setBatch(this.aspirator.data.aspirator.batch_time)
    }
  }

}

</script>
<style lang="scss" scoped>
.exgauster-scheme-text {
  z-index: 1;
  font-weight: 600;
  font-size: 0.7vw;
  position: absolute;
  color: white;


}

.highlighted-val {
  display: flex !important;
  flex-direction: row;
  justify-content: space-between;
  background-color: $warning-accent;
  border-radius: 2px;
  padding: 0 4px 0 4px;
}

.liquid-measure {
  background-color: $secondary;
  height: 20px;
  padding-left: 3px;
}

.alarm {
  background-color: #EB5835;
}

.ok {
  background-color: #9CC983;
}

.warning {
  background-color: #FAB82E;
}
</style>
<style lang="scss">
.card-link-btn {
  padding: 0;
  height: 32px;
  width: 32px;
  display: flex;
  position: absolute;
  justify-content: center;
  align-items: center;
  background: #FAFAFA;
  border: 1px solid #EAEAEA;
  border-radius: 4px;

  & :hover {
    cursor: pointer;
  }
}
</style>
