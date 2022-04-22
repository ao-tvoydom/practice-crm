<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Товары на складах</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/product_in_storage`)">+</button>
  </div>

  <table class="table table-zebra w-full">
    <thead>
    <tr>
      <th>Название товара</th>
      <th>Вес</th>
      <th>Высота</th>
      <th>Ширина</th>
      <th>Длинна</th>
      <th>Название склада</th>
      <th>Адрес</th>
      <th>Количество товара</th>
      <th>Действия</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="productInWarehouse in productsInWarehouse" :key="productInWarehouse.productInWarehouseId">
      <td>{{ productInWarehouse.product.name }}</td>
      <td>{{ productInWarehouse.product.weight }}</td>
      <td>{{ productInWarehouse.product.height }}</td>
      <td>{{ productInWarehouse.product.width }}</td>
      <td>{{ productInWarehouse.product.length }}</td>
      <td>{{ productInWarehouse.warehouse.name }}</td>
      <td>{{ productInWarehouse.warehouse.address }}</td>
      <td>{{ productInWarehouse.amount }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/product_in_storage/${productInWarehouse.productInWarehouseId}`">Подробнее</router-link></li>
            <li><router-link :to="`/product_in_storage/${productInWarehouse.productInWarehouseId}/edit`">Редактировать</router-link></li>
            <li><a class="text-error" @click="deleteProductInWarehouse(productInWarehouse.productInWarehouseId)">Удалить</a></li>
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
  name: "ProductsInStorage",
  data() {
    return {
      productsInWarehouse: []
    }
  },
  methods: {
    deleteProductInWarehouse(id) {
      axios.delete(`/ProductInWarehouse/${id}`).then(() => {
        this.productsInWarehouse = this.productsInWarehouse.filter(function (productInWarehouse) {
          return productInWarehouse.productInWarehouseId !== id
        })
      })
    }
  },
  created() {
    axios.get('/ProductInWarehouse').then((response) => this.productsInWarehouse = response.data)
  }
}
</script>