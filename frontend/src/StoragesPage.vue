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
    <tr v-for="storage in storages" :key="storage.name">
      <td>{{ storage.name }}</td>
      <td>{{ storage.address }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn m-1 p-2 rounded">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><a>Перейти</a></li>
            <li><a>Изменить</a></li>
            <li><a>Удалить</a></li>
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
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
        { name: "Москва ЮВАО", address: "г. Москва ул. 7-я Текстильщиков д.1" },
      ]
    }
  }
}
</script>

<style scoped>

</style>