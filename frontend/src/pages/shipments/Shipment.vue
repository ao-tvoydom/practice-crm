<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Отгрузка № {{ shipment.shipmentId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Целевой адрес</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="shipment.targetAddress">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Дата начала отгрузки</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="shipment.shipmentStartDate">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Дата окончания отгрузки</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="shipment.shipmentEndDate">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Контактный телефон</span>
      </label>
      <input type="text" class="input input-bordered w-full" readonly v-model="shipment.contactPhone">
    </div>

    <button class="btn btn-primary mt-4" @click="this.$router.push(`/shipment/${shipment.shipmentId}/edit`)">Редактировать</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "ShipmentPage",
  data() {
    return {
      shipment: {
        shipmentId: this.$route.params.id,
      }
    }
  },
  created() {
    axios.get(`/Shipment/${this.shipment.shipmentId}`).then((response) => this.shipment = response.data)
  }
}
</script>

<style scoped>

</style>