<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto overflow-visible ">
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

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Категории</span>
      </label>
      <Multiselect
          v-model="product.categoryIdArray"
          :close-on-select="false"
          :options="categories"
          mode="tags"
          :classes="multiselectClasses"
      />
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>

</template>
<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";

export default {
  name: "CreateProductPage",
  data() {
    return {
      product: {
        categoryIdArray: []
      },
      categories: {},
      multiselectClasses
    }
  },
  components: {
    Multiselect
  },
  methods: {
    save() {
      axios.post(`/Product`, this.product).then((response) => {
        this.$router.push(`/product/${response.data.productId}`)
      })
    }
  },
  created() {
    axios.get('/Category').then((response) => {
      this.categories = response.data.map((category) => {
        return { value: category.categoryId, label: category.name }
      })
    })
  }
}
</script>

<style src="@vueform/multiselect/themes/default.css"></style>
