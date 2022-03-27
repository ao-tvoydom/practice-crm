<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить склад {{ storage.storageId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название</span>
      </label>
      <input type="text" class="input input-bordered w-full " v-model="storage.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Адрес</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="storage.address">
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
      storage: {
        storageId: this.$route.params.id,
      }
    }
  },
  methods: {
    save() {
      axios.post(`/Storage`, this.storage).then((response) => {
        this.$router.push(`/storage/${response.data.storageId}`)
      })
    }
  }
}
</script>