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
              <li><router-link :to="`/product/${product.productId}`">Подробнее</router-link></li>
              <li><router-link :to="`/product/${product.productId}}/edit`">Редактировать</router-link></li>
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
        { productId: 1, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 2, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 3, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 4, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 5, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 6, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 7, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
        { productId: 8, name: "САХАР", weight: 100, height: 20, width: 20, length: 5 },
      ]
    }
  }

}
</script>