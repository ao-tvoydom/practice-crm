<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Товары</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/product`)">+</button>
  </div>

  <table class="table table-zebra w-full">
    <thead>
      <tr>
        <th>Название</th>
        <th>Вес</th>
        <th>Высота</th>
        <th>Ширина</th>
        <th>Длинна</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="product in products" :key="product.name">
        <td>{{ product.name }}</td>
        <td>{{ product.weight }}</td>
        <td>{{ product.height }}</td>
        <td>{{ product.width }}</td>
        <td>{{ product.length }}</td>
        <td>
          <div class="dropdown dropdown-end">
            <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2">...</label>
            <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
              <li><router-link :to="`/product/${product.productId}`">Подробнее</router-link></li>
              <li><router-link :to="`/product/${product.productId}/edit`">Редактировать</router-link></li>
              <li><a class="text-error" @click="deleteProduct(product.productId)">Удалить</a></li>
            </ul>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import axios from "@/axios";

export default {
  name: "ProductsPage",
  data() {
    return {
      products: []
    }
  },
  methods: {
    deleteProduct(id) {
      axios.delete(`/Product/${id}`).then(() => {
        this.products = this.products.filter(function (product) {
          return product.productId !== id
        })
      })
    }
  },
  created() {
    axios.get('/Product').then((response) => this.products = response.data)
  }

}
</script>