<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Поставки</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/supply`)">+</button>
  </div>

  <table class="table table-zebra w-full">
    <thead>
      <tr>
        <th>Товар</th>
        <th>Склад</th>
        <th>Поставщик</th>
        <th>Количество</th>
        <th>Дата</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="supply in supplies" :key="supply.supplyId">
        <td>{{ supply.productInWarehouse.product.name }}</td>
        <td>{{ supply.productInWarehouse.warehouse.name }}</td>
        <td>{{ supply.supplierName }}</td>
        <td>{{ supply.amount }}</td>
        <td>{{ supply.date }}</td>
        <td>
          <div class="dropdown dropdown-end">
            <label tabindex="0" class="btn btn-primary btn-square btn-sm m-1 p-2 rounded">...</label>
            <ul tabindex="0" class="dropdown-content  menu p-2 shadow bg-base-100 rounded w-52">
              <li><router-link :to="`/supply/${supply.supplyId}`">Подробнее</router-link></li>
              <li><router-link :to="`/supply/${supply.supplyId}/edit`">Редактировать</router-link></li>
              <li><a class="text-error" @click="deleteSupply(supply.supplyId)">Удалить</a></li>
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
  name: "SuppliesPage",
  data() {
    return {
      supplies: []
    }
  },
  methods: {
    deleteSupply(id) {
      axios.delete(`/Supply/${id}`).then(() => {
        this.supplies = this.supplies.filter(function (supply) {
          return supply.supplyId !== id
        })
      })
    }
  },
  created() {
    axios.get('/Supply').then((response) => this.supplies = response.data)
  }
}
</script>