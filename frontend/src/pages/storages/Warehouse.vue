<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Склад</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название склада</span>
      </label>
      <input type="text" class="input input-bordered w-full  text-neutral" readonly v-model="warehouse.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Адрес склада</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" readonly v-model="warehouse.address">
    </div>

    <button class="btn btn-primary mt-4" @click="this.$router.push(`/warehouse/${warehouse.warehouseId}/edit`)">Редактировать</button>

  </div>

</template>

<script>
import axios from "@/axios";

export default {
  name: "WarehousePage",
  data() {
    return {
      warehouse: {
        warehouseId: this.$route.params.id,
        name: "",
        address: "",
      }
    }
  },
  created() {
    axios.get(`/Warehouse/${this.warehouse.warehouseId}`).then((response) => this.warehouse = response.data)
  }
}
</script>
