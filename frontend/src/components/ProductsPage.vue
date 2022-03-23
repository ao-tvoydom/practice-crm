<template>
  <div class="text-3xl">Товары</div>
  <table class="w-full">
    <tr>
      <th class="border-2">Название</th>
      <th class="border-2">Вес</th>
      <th class="border-2">Высота</th>
      <th class="border-2">Ширина</th>
      <th class="border-2">Длинна</th>
    </tr>
    <tr v-for="product in products" :key="product.name">
      <td class="border-2 p-1" >{{ product.name }}</td>
      <td class="border-2 p-1">{{ product.weight }}</td>
      <td class="border-2 p-1">{{ product.height }}</td>
      <td class="border-2 p-1">{{ product.width }}</td>
      <td class="border-2 p-1">{{ product.length }}</td>
    </tr>
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