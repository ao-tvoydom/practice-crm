<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить товар {{ product.productId }}</div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="product.name">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Вес</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="product.weight">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Высота</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="product.height">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Ширина</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="product.width">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Длинна</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="product.length">
    </div>
    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "CreateProductPage",
  data() {
    return {
      product: {}
    }
  },
  methods: {
    save() {
      axios.post(`/Product`, this.product).then((response) => {
        this.$router.push(`/product/${response.data.productId}`)
      })
    }
  }
}
</script>

<style scoped>

</style>