<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Склады</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/storage`)">+</button>
  </div>
  <table class="table table-zebra w-full">
    <thead>

    <tr>
      <th>Название</th>
      <th>Аддрес</th>
      <th>Действия</th>
    </tr>
    
    </thead>
    <tbody>

    <tr v-for="storage in storages" :key="storage.storageId">
      <td>{{ storage.name }}</td>
      <td>{{ storage.address }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2 rounded">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/storage/${storage.storageId}`">Подробнее</router-link></li>
            <li><router-link :to="`/storage/${storage.storageId}/edit`">Редактировать</router-link></li>
            <li><a class="text-error" @click="deleteStorage(storage.storageId)">Удалить</a></li>
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
  name: "StoragesPage",
  data() {
    return {
      storages: []
    }
  },
  methods: {
    deleteStorage(id) {
      axios.delete(`/Storage/${id}`).then(() => {
        this.storages = this.storages.filter(function (storage) {
          return storage.storageId !== id
        })
      })
    }
  },
  created() {
    axios.get('/Storage').then((response) => this.storages = response.data)
  }
}
</script>