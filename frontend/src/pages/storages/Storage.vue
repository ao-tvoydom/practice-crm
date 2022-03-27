<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Склад № {{ storage.storageId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название склада</span>
      </label>
      <input type="text" class="input input-bordered w-full  text-neutral" readonly v-model="storage.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Адрес склада</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" readonly v-model="storage.address">
    </div>

    <button class="btn btn-primary mt-4" @click="this.$router.push(`/storage/${storage.storageId}/edit`)">Редактировать</button>

  </div>

</template>

<script>
import axios from "@/axios";

export default {
  name: "StoragePage",
  data() {
    return {
      storage: {
        storageId: this.$route.params.id,
        name: "",
        address: "",
      }
    }
  },
  created() {
    axios.get(`/Storage/${this.storage.storageId}`).then((response) => this.storage = response.data)
  }
}
</script>

<style scoped>

</style>