<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Категория</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="category.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Цвет</span>
      </label>

      <div class="tooltip tooltip-primary tooltip-primary" :data-tip="category.colorHex">
        <input type="color" class="input input-bordered w-full p-2" v-model="category.colorHex">
      </div>

    </div>

    <button class="btn btn-primary mt-4" @click="this.$router.push(`/category/${category.categoryId}/edit`)">Редактировать</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "ProductPage",
  data() {
    return {
      category: {
        categoryId: this.$route.params.id,
      }
    }
  },
  created() {
    axios.get(`/Category/${this.category.categoryId}`).then((response) => {
      this.category = response.data
      this.category.colorHex = `#${this.category.colorHex}`
    })
  }
}
</script>

<style scoped>

</style>