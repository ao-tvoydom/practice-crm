<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить категорию</div>

    <TextField name="Название" :vfield="v$.category.name" v-model="category.name"></TextField>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Цвет</span>
      </label>

      <div class="tooltip tooltip-primary tooltip-primary" :data-tip="category.color">
        <input type="color" class="input input-bordered w-full p-2" v-model="category.color">
      </div>

    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";
import useVuelidate from "@vuelidate/core";
import validators from "@/validators";
import TextField from "@/controls/TextField";

export default {
  name: "CreateCategoryPage",
  components: {TextField},
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      category: {
        name: "",
        color: "#000000"
      }
    }
  },
  validations () {
    return {
      category: {
        name: { checkLength: validators.checkLength(3, 40) }
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.post(`/Category`, this.category).then((response) => {
        this.$router.push(`/category/${response.data.categoryId}`)
      })
    }
  }
}
</script>