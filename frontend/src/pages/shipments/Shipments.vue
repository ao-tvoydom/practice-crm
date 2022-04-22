<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Отгрузки</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/shipment`)">+</button>
  </div>
  <table class="table table-zebra w-full">

    <thead>
    <tr>
      <th>Целевой адрес</th>
      <th>Дата начала отгрузки</th>
      <th>Дата окончания отгрузки</th>
      <th>Контактный телефон</th>
      <th>Действия</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="shipment in shipments" :key="shipment.name">
      <td>{{ shipment.targetAddress }}</td>
      <td>{{ shipment.shipmentStartDate }}</td>
      <td>{{ shipment.shipmentEndDate }}</td>
      <td>{{ shipment.contactPhone }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/shipment/${shipment.shipmentId}`">Подробнее</router-link></li>
            <li><router-link :to="`/shipment/${shipment.shipmentId}/edit`">Редактировать</router-link></li>
            <li><a class="text-error" @click="deleteShipment(shipment.shipmentId)">Удалить</a></li>
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
  name: "ShipmentsPage",
  data() {
    return {
      shipments: []
    }
  },
  methods: {
    deleteShipment(id) {
      axios.delete(`/Shipment/${id}`).then(() => {
        this.shipments = this.shipments.filter(function (shipment) {
          return shipment.shipmentId !== id
        })
      })
    }
  },
  created() {
    axios.get('/Shipment').then((response) => this.shipments = response.data)
  }
}
</script>