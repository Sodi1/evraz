import { defineStore } from "pinia";

export default defineStore("offset", {
  state: () => ({
    offset: null,
    batch: null,
  }),
  getters: {},
  actions: {
    setOffset(offset) {
      if (offset > 352 && offset < 32567) {
        this.offset = offset;
      } else {
        this.offset = null;
        this.batch = null;
      }
    },
    setBatch(batch) {
      this.batch = batch;
    },
  },
  persist: {
    enabled: true,
  },
});
