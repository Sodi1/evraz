<template>
  <div class="chart-group-container">
    <div>
      <apexchart type="line" :height="720" :options="chartOptionsArea" :series="filteredSeries" />
    </div>
    <div class="slider-container">
      <q-range v-model="range" @change="setC" :step="0.001" :min="0" :max="1" />
    </div>
  </div>
</template>

<script setup>
import { ref, defineProps, computed } from "vue"

const chartOptionsArea = {
  chart: {
    id: "chartArea",
    animations: {
      enabled: false,

    },
    toolbar: {
      autoSelected: "pan",
      show: false
    }
  },
  colors: ["#696969", "#2e8b57", "#7f0000", "#191970",
    "#808000", "#ff0000", "#ff8c00", "#ffff00", "#00ff00",
    "#ba55d3", "#00fa9a", "#00ffff", "#0000ff", "#ff00ff",
    "#1e90ff", "#fa8072", "#eee8aa", "#dda0dd", "#ff1493",
    "#87cefa"],
  stroke: {
    width: 3
  },
  dataLabels: {
    enabled: false
  },
  fill: {
    opacity: 1
  },
  markers: {
    size: 0
  },
  xaxis: {
    type: "datetime"
  },
  yaxis: {
    decimalsInFloat: 2
  }
}
function setC(v) {
  c.value = v
}
const c = ref({ min: 0, max: 1 })
const props = defineProps({
  charts: Object,
  names: Array,
  predictedChart: Array,
})
const filteredSeries = computed(() => {
  if (props?.charts?.charts) {
    const series = []
    props.charts.charts.forEach((v, i) => {
      series.push({ data: v[Object.keys(v)[0]], name: props.names[i] })
    })
    series.forEach((s, i) => {
      series[i].data = s.data.slice(s.data.length * c.value.min, s.data.length * c.value.max)
    })
    if (props.predictedChart) {
      series.push({ data: props.predictedChart })
    }
    return series
  }

  return [{ data: [] }]
})

const range = ref({ min: 0, max: 1 })


</script>

<style lang="scss" scoped>
.chart-group-container {
  padding: 20px;

  .slider-container {
    padding: 0 12px 20px 40px;
  }
}
</style>
