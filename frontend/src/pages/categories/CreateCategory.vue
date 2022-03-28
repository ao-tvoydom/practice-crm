<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить категорию {{ category.categoryId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="category.name">
    </div>

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

export default {
  name: "CreateCategoryPage",
  data() {
    return {
      category: {
        name: "",
        color: "#000000"
      }
    }
  },
  methods: {
    save() {
      axios.post(`/Category`, this.category).then((response) => {
        this.$router.push(`/category/${response.data.categoryId}`)
      })
    }
  }
}
</script>