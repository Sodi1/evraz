<template>
  <div id="q-app">
    <div class="q-pa-md">
      <q-table
        title="Treats"
        :rows="rows_requests"
        :columns="columns"
        row-key="name"
        :pagination="{rowsPerPage:20}"
      >
        <h1>Заявки</h1>

        <template v-slot:top>
          <div style="width: 100%" class="row">
            <div class="col-9">
              <q-toggle v-model="openIssue" @click="this.refreshIssue" val="openIssue" label="Открытые заявки" />
            </div>
            <div class="col-3">
              <q-input  dense debounce="400" color="primary" v-model="search">
                <template v-slot:append>
                  <q-icon name="search" />
                </template>
              </q-input>
            </div>
          </div>
        </template>
      </q-table>
    </div>
  </div>
</template>
<script>
import IssueService from "src/services/IssueService";
import moment from 'moment'

export default {
  data() {
    return {
      openIssue: true,
      issues: [],
      search: '',
      columns: [
        {name: 'id', label: 'id', align: 'center', field: row => row?.id, sortable: true},
        {name: 'exhauster', label: 'Эксгаустер', align: 'center', field: row => row?.aspirator?.name, sortable: true},
        {name: 'error', label: 'Ошибка', align: 'center', field: row => row.description, sortable: true},
        {name: 'dateTime', label: 'Дата время', align: 'center', field: row => moment(row?.signal_value?.batch_time).format('M-DD-YYYY hh:mm:ss'), sortable: true},
        {name: 'signalCode', label: 'Код сигнала', align: 'center', field: row => row?.signal_value?.signal_kind_code, sortable: true},
        {name: 'signal', label: 'Сигнал', align: 'center', field: row => row?.signal_value?.signal_kind_short_name, sortable: true},
        {name: 'value', label: 'Значение', align: 'center', field: row => row?.signal_value?.value?.toFixed(2), sortable: true},
        {name: 'signalKindDimension', label: 'Ед.измр.', align: 'center', field: row => row?.signal_value?.signal_kind_dimension, sortable: true},
        {name: 'state', label: 'Статус.', align: 'center', field: row => row?.state, sortable: true}
      ]
    }
  },
  computed: {
    showAll: {
      get: function () {
        return this.openIssue
      },
      set: function (newValue) {
        this.openIssue = newValue
      }
    },
    filter() {
      return {
        search: this.search,
        breakfast: this.openIssue
      }
    },
    rows_requests: function () {
      return this.issues?.data?.issue_requests;
    }
  },
  async created() {
    setInterval(async () => {
      this.issues = await IssueService.getIssues(this.openIssue)
    }, 5000)
  },
  methods: {
    async refreshIssue(){
      this.issues = await IssueService.getIssues(this.openIssue)
    },
    customFilter(rows, terms) {
      // rows contain the entire data
      // terms contains whatever you have as filter

      lowerSearch = terms.search ? terms.search.toLowerCase() : ""

      const filteredRows = rows.filter(
        (row, i) => {
          let ans = false

          //Gather toggle conditions
          let c1 = this.filterToggle.breakfast //&& row.category == "openIssue"

          //Assume true in case there is no search
          let s1 = true

          //If search term exists, convert to lower case and see which rows contain it
          if (lowerSearch != "") {
            s1 = false
            //Get the values
            let s1_values = Object.values(row)
            //Convert to lowercase
            let s1_lower = s1_values.map(x => x.toString().toLowerCase())

            for (let val = 0; val < s1_lower.length; val++) {
              if (s1_lower[val].includes(lowerSearch)) {
                s1 = true
                break
              }
            }
          }

          //assume row doesn't match
          ans = false

          //check if any of the conditions match
          if ((c1 && s1) || (c2 && s1) || (c3 && s1)) {
            ans = true
          }

          return ans

        })


      return filteredRows
    }
  }
}

</script>
<style lang="scss" scoped>

</style>
