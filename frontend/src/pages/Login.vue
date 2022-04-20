<template>
  <div class="card bg-neutral p-4 w-1/6 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Вход в систему</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Логин</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="user.login">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Пароль</span>
      </label>
      <input type="password" class="input input-bordered w-full" v-model="user.password">
    </div>

    <button class="btn btn-primary mt-4" @click="login">Войти</button>
    <router-link class="text-xl m-2 text-neutral-content cursor-pointer hover:text-secondary" to="/register">Регистрация</router-link>

  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "LoginPage",
  data() {
    return {
      user: {
        login: "",
        password: ""
      }
    }
  },
  methods: {
    login() {
      axios.post(`/Account/Login`, this.user).then(() => {
        this.$router.push('/')
      })
    }
  }
}
</script>