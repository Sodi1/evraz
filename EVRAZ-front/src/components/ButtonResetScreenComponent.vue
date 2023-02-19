<template>
  <q-btn v-scroll="onScroll" icon="arrow_upward" :class="{'button-stick':true, 'button-shown':showButton}"
         @click="scrollScreen" text-color="primary" size="24px">

  </q-btn>
</template>
<script setup lang="ts">
import { ref } from "vue"
const showButton = ref(false)
function onScroll(pos) {
  if (pos > window.innerHeight) {
    showButton.value = true
  } else {
    showButton.value = false
  }
}

function scrollScreen() {
  window.scrollTo({ top: 0, behavior: 'smooth' });
}
</script>
<style scoped lang="scss">
.button-stick {
  background-color: $background1;
  border-radius: 100%;
  border: 2px solid $primary;
  height: 60px;
  width: 60px;
  position: fixed;
  bottom: 20px;
  right: 20px;
  transition: all 0.4s;
  opacity: 0;
}

.button-shown {
  opacity: 1;
  transform: translateY(10px);
}
</style>
