<template>
  <div class="card bg-neutral p-4 w-1/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Регистрация в системе</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Логин</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="user.form.email">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Пароль</span>
      </label>
      <input type="password" class="input input-bordered w-full" v-model="user.form.password">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Подтверждение пароля</span>
      </label>
      <input type="password" class="input input-bordered w-full" v-model="user.passwordConfirmation">
    </div>

    <button class="btn btn-primary mt-4" @click="register">Зарегистрироваться</button>
    <router-link class="text-xl m-2 text-neutral-content cursor-pointer hover:text-secondary" to="/login">Вход</router-link>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "LoginPage",
  data() {
    return {
      user: {
        form: {
          email: "",
          password: "",
        },
        passwordConfirmation: ""
      }
    }
  },
  methods: {
    register() {
      axios.post(`/Account/Register`, this.user.form).then(() => {
        this.$router.push('/')
      })
    }
  }
}
</script>