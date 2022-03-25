<template>
  <div class="text-3xl mb-2">Склады</div>
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
          <label tabindex="0" class="btn btn-primary m-1 p-2 rounded">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><router-link :to="`/storage/${storage.storageId}`">Подробнее</router-link></li>
            <li><router-link :to="`/storage/${storage.storageId}/edit`">Редактировать</router-link></li>
          </ul>
        </div>
      </td>
    </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "StoragesPage",
  data() {
    return {
      storages: [
        { storageId: 1, name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { storageId: 2, name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { storageId: 3, name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { storageId: 4, name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { storageId: 5, name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
      ]
    }
  }
}
</script>

<style scoped>

</style>