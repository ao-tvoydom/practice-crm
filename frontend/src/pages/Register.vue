<template>
  <div class="card bg-neutral p-4 w-1/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Регистрация в системе</div>

    <TextField name="Логин" :vfield="v$.user.form.email" v-model="user.form.email"></TextField>
    <TextField name="Пароль" :vfield="v$.user.form.password" v-model="user.form.password" type="password"></TextField>

    <div class="form-control w-full">
      <label class="label justify-start">
        <span class="label-text text-neutral-content mr-2">Подтверждение пароля</span>
        <span class="label-text text-error" v-if="!passwordsOverlap">( пароли не совпадают )</span>
      </label>
      <input type="password" class="input input-bordered w-full" v-model="user.passwordConfirmation">
    </div>

    <button class="btn btn-primary mt-4" @click="register">Зарегистрироваться</button>
    <router-link class="text-xl m-2 text-neutral-content cursor-pointer hover:text-secondary" to="/login">Вход</router-link>
  </div>
</template>

<script>
import axios from "@/axios";
import validators from "@/validators";
import TextField from "@/controls/TextField";
import useVuelidate from "@vuelidate/core";

export default {
  name: "LoginPage",
  components: {TextField},
  setup () {
    return { v$: useVuelidate() }
  },
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
    async register() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect || !this.passwordsOverlap) return;
      axios.post(`/Account/Register`, this.user.form).then(() => {
        this.$router.push('/');
      })
    }
  },
  computed: {
    passwordsOverlap() {
      return this.user.form.password === this.user.passwordConfirmation;
    }
  },
  validations () {
    return {
      user: {
        form: {
          email: {
            checkLength: validators.checkLength(3, 15),
          },
          password: {
            checkLength: validators.checkLength(8, 64),
          }
        }
      }
    }
  },
}
</script>