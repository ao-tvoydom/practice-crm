<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Отгрузки на склад</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/shipment_content`)">+</button>
  </div>

  <table class="table table-zebra w-full">
    <thead>
    <tr>
      <th>Продукт на складе</th>
      <th>Адрес отгрузки</th>
      <th>Количество</th>
      <th>Действия</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="shipmentContent in shipmentContents" :key="shipmentContent.shipmentContentId">
      <td>{{ shipmentContent.productInWarehouse.product.name }}</td>
      <td>{{ shipmentContent.shipment.targetAddress }}</td>
      <td>{{ shipmentContent.amount }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-primary btn-square btn-sm m-1 p-2 rounded">...</label>
          <ul tabindex="0" class="dropdown-content  menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/shipment_content/${shipmentContent.shipmentContentId}`">Подробнее</router-link></li>
            <li><router-link :to="`/shipment_content/${shipmentContent.shipmentContentId}/edit`">Редактировать</router-link></li>
            <li><a class="text-error" @click="deleteSupply(shipmentContent.shipmentContentId)">Удалить</a></li>
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
      shipmentContents: []
    }
  },
  methods: {
    deleteSupply(id) {
      axios.delete(`/ShipmentContent/${id}`).then(() => {
        this.shipmentContents = this.shipmentContents.filter(function (shipmentContent) {
          return shipmentContent.shipmentContentId !== id
        })
      })
    }
  },
  created() {
    axios.get('/ShipmentContent').then((response) => this.shipmentContents = response.data)
  }
}
</script>