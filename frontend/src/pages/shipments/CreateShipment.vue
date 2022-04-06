<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить отгрузку {{ shipment.shipmentId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Целевой адрес</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.targetAddress">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Дата начала отгрузки</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.shipmentStartDate">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Дата окончания отгрузки</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.shipmentEndDate">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Контактный телефон</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.contactPhone">
    </div>
    
    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "CreateShipmentPage",
  data() {
    return {
      shipment: {}
    }
  },
  methods: {
    save() {
      axios.post(`/Shipment`, this.shipment).then((response) => {
        this.$router.push(`/shipment/${response.data.shipmentId}`)
      })
    }
  }
}
</script>