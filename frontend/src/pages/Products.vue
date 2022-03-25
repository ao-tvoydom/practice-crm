<template>
  <div class="text-3xl mb-2">Товары</div>
  <table class="table table-zebra w-full">
    <thead>
      <tr>
        <th>Название</th>
        <th>Вес</th>
        <th>Высота</th>
        <th>Ширина</th>
        <th>Длинна</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="product in products" :key="product.name">
        <td>{{ product.name }}</td>
        <td>{{ product.weight }}</td>
        <td>{{ product.height }}</td>
        <td>{{ product.width }}</td>
        <td>{{ product.length }}</td>
        <td>
          <div class="dropdown dropdown-end">
            <label tabindex="0" class="btn btn-primary m-1 p-2 rounded">...</label>
            <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
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
  name: "ProductsPage",
  data() {
    return {
      products: [
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
        { name: "САХАР", weight: 500, height: 20, width: 20, length: 5 },
      ]
    }
  }

}
</script>