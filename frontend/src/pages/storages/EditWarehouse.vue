<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Редактировать склад</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название склада</span>
      </label>
      <input type="text" class="input input-bordered w-full  text-neutral" v-model="warehouse.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Адрес склада</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="warehouse.address">
    </div>
    
    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/warehouse/${warehouse.warehouseId}`)">Простмотр</button>

  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "EditStoragePage",
  data() {
    return {
      warehouse: {
        warehouseId: this.$route.params.id,
        name: "",
        address: "",
      }
    }
  },
  methods: {
    save() {
      axios.put(`/Warehouse/${this.warehouse.warehouseId}`, this.warehouse).then(() => {
        this.$router.push(`/warehouse/${this.warehouse.warehouseId}`)
      })
    }
  },
  created() {
    axios.get(`/Warehouse/${this.warehouse.warehouseId}`).then((response) => this.warehouse = response.data)
  }
}
</script>

<style scoped>

</style>