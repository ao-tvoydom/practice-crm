<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Товар № {{ product.productId }}</div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full  text-neutral" v-model="product.name">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Вес</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="product.weight">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Высота</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="product.height">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Ширина</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="product.width">
    </div>
    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Длинна</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="product.length">
    </div>
    <button class="btn btn-primary mt-4">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product/${product.productId}`)">Простмотр</button>
  </div>
</template>

<script>
export default {
  name: "EditProductPage",
  data() {
    return {
      product: {
        productId: 1,
        name: "САХАР",
        weight: 100,
        height: 20,
        width: 20,
        length: 5
      }
    }
  }
}
</script>

<style scoped>

</style>