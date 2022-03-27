<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Товар № {{ product.productId }}</div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="product.name">
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
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product/${product.productId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "EditProductPage",
  data() {
    return {
      product: {
        productId: this.$route.params.id
      }
    }
  },
  methods: {
    save() {
      axios.put(`/Product/${this.product.productId}`, this.product).then(() => {
        this.$router.push(`/product/${this.product.productId}`)
      })
    }
  },
  created() {
    axios.get(`/Product/${this.product.productId}`).then((response) => this.product = response.data)
  }
}
</script>

<style scoped>

</style>