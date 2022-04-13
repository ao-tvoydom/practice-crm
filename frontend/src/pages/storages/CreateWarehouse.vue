<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить склад</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="warehouse.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Адрес</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="warehouse.address">
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "CreateStoragePage",
  data() {
    return {
      warehouse: {
        warehouseId: this.$route.params.id,
      }
    }
  },
  methods: {
    save() {
      axios.post(`/Warehouse`, this.warehouse).then((response) => {
        this.$router.push(`/warehouse/${response.data.warehouseId}`)
      })
    }
  }
}
</script>