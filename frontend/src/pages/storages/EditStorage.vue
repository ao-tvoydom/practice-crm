<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Склад № {{ storage.storageId }}</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название склада</span>
      </label>
      <input type="text" class="input input-bordered w-full  text-neutral" v-model="storage.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Адрес склада</span>
      </label>
      <input type="text" class="input input-bordered w-full text-neutral" v-model="storage.address">
    </div>
    
    <button class="btn btn-primary mt-4">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/storage/${storage.storageId}`)">Простмотр</button>

  </div>
</template>

<script>
export default {
  name: "EditStoragePage",
  data() {
    return {
      storage: {
        storageId: this.$route.params.id,
        name: "Склад 1",
        address: "Рязанский проспект 11А",
      }
    }
  }
}
</script>

<style scoped>

</style>