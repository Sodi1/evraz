<template>
  <div class="wrapper">
    <div class="card">
      <div class="welcome-label"><span style="font-size: 40px">
              <img src="~assets/evraz-logo.svg" class="cursor-pointer" style="width: 200px" />

      </span></div>

      <q-form @submit="loginUser(formData.name, formData.password)">
        <q-input v-model="formData.name" @update:model-value="error = false" :error="error" :rules='[v => !!v || ""]'
          dense label="Логин" hint="Введите логин" counter maxlength="20" />

        <q-input v-model="formData.password" @update:model-value="error = false" :error="error"
          :rules='[v => !!v || ""]' dense type="password" label="Пароль" hint="Укажите пароль" counter maxlength="20"
          style="margin-top: 24px" />

        <div class="buttons">
          <q-btn type="submit" unelevated rounded color="primary" class="button">
            Продолжить
          </q-btn>
          <div class="separator"><span>Или</span></div>
          <q-btn outline rounded color="primary" @click="loginUser('predictodemo', 'predictodemo')" class="button">
            Войти как гость
          </q-btn>
        </div>
      </q-form>
    </div>
  </div>
</template>


<script setup>
import { useUserStore } from "src/stores/user"
import { reactive, ref } from "vue";
import { useRouter } from 'vue-router'

const userStorage = useUserStore()
const router = useRouter()
const error = ref(false)

const formData = reactive({
  name: "",
  password: "",
});

async function loginUser(login, pass) {
  const isValid = await userStorage.login(login, pass)
  if (isValid) {
    router.push('/')
  } else {
    error.value = true
  }
}
</script>

<style scoped lang="scss">
.wrapper {
  background-size: 100%;
  height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

.card {
  width: 540px;
  border-radius: 16px;
  padding: 32px;
  box-shadow: 0px 10px 30px rgba(210, 209, 222, 0.5);
  background: white;
  text-align: center;

  .welcome-label {
    font-size: 48px;
    line-height: 50px;
    text-align: center;
    margin: 24px 0;
  }

  .buttons {
    margin-top: 24px;

    .button {
      margin-top: 20px;
      width: 320px;
      height: 64px;
      border-radius: 54px;
      font-weight: 500;
    }

    .separator {
      width: 100%;
      text-align: center;
      color: $secondary;
      border-bottom: 1px solid $secondary;
      line-height: 0.1em;
      margin: 18px 0;

      span {
        background: #fff;
        padding: 0 10px;
      }
    }
  }
}
</style>
