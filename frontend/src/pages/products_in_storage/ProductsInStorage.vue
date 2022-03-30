<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Товары на складах</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/product`)">+</button>
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
    <tr v-for="productInStorage in productsInStorage" :key="productInStorage.productInWarehouseId">
      <td>{{ productInStorage.product.name }}</td>
      <td>{{ productInStorage.product.weight }}</td>
      <td>{{ productInStorage.product.height }}</td>
      <td>{{ productInStorage.product.width }}</td>
      <td>{{ productInStorage.product.length }}</td>
      <td>{{ productInStorage.warehouse.name }}</td>
      <td>{{ productInStorage.warehouse.address }}</td>
      <td>{{ productInStorage.amount }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/product_in_warehouse/${productsInStorage.productInWarehouseId}`">Подробнее</router-link></li>
            <li><router-link :to="`/product_in_warehouse/${productsInStorage.productInWarehouseId}/edit`">Редактировать</router-link></li>
            <li><a class="text-error" @click="deleteProductInWarehouse(productsInStorage.productInWarehouseId)">Удалить</a></li>
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
      productsInStorage: [
        {
          productInWarehouseId: 0,
          amount:0,
          product: {
            productId: 0,
            name: "",
            weight: 0,
            height: 0,
            width: 0,
            length: 0
          },
          warehouse: {
            warehouseId: 0,
            name: "",
            address: ""
          }
        }
      ]
    }
  },
  methods: {
    deleteProductInWarehouse(id) {
      axios.delete(`/ProductInWarehouse/${id}`).then(() => {
        this.productsInStorage = this.productsInStorage.filter(function (productInStorage) {
          return productInStorage.productInWarehouseId !== id
        })
      })
    }
  },
  created() {
    axios.get('/ProductInWarehouse').then((response) => this.productsInStorage = response.data)
  }

}
</script>