<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Товар № {{ product.productId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="product.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Вес</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="product.weight">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Высота</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="product.height">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Ширина</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="product.width">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Длинна</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="product.length">
    </div>
    
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product/${product.productId}/edit`)">Редактировать</button>
  </div>
  <div class="form-control w-full">
    <label class="label">
      <span class="label-text text-neutral-content">Категории</span>
    </label>
    <Multiselect
        v-model="product.categoryIdArray"
        :close-on-select="false"
        :options="categories"
        disabled
        mode="tags"
        :classes="multiselectClasses"
    />
  </div>
</template>

<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";

export default {
  name: "ProductPage",
  data() {
    return {
      product: {
        productId: this.$route.params.id,
        name: "",
        weight: "",
        height: "",
        width: "",
        length: "",
        categoryIdArray: []
      },
      categories: [],
      multiselectClasses
    }
  },
  components: {
    Multiselect
  },
  created() {
    axios.get(`/Product/${this.product.productId}`).then((response) => this.product = response.data)
    axios.get('/Category').then((response) => {
      this.categories = response.data.map((category) => {
        return { value: category.categoryId, label: category.name }
      })
    })
  }
}
</script>

<style scoped>

</style>