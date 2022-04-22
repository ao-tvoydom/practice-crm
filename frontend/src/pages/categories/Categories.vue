<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Категории</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/category`)">+</button>
  </div>

  <table class="table table-zebra w-full">
    <thead>
      <tr>
        <th>Название</th>
        <th>Цвет</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(category, index) in categories" :key="category.categoryId">
        <td>{{ category.name }}</td>
        <td>
          <div class="tooltip tooltip-bottom" :data-tip="category.color">
            <div class="w-6 h-6 rounded" :style="categoryColor(index)"></div>
          </div>
        </td>
        <td>
          <div class="dropdown dropdown-end">
            <label tabindex="0" class="btn btn-square btn-sm btn-primary m-1 p-2">...</label>
            <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
              <li><router-link :to="`/category/${category.categoryId}`">Подробнее</router-link></li>
              <li><router-link :to="`/category/${category.categoryId}/edit`">Редактировать</router-link></li>
              <li><a class="text-error" @click="deleteCategory(category.categoryId)">Удалить</a></li>
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
  name: "CategoriesPage",
  data() {
    return {
      categories: []
    }
  },
  methods: {
    deleteCategory(id) {
      axios.delete(`/Category/${id}`).then(() => {
        this.categories = this.categories.filter(function (category) {
          return category.categoryId !== id
        })
      })
    },
    categoryColor(categoryIndex) {
      return `background: ${this.categories[categoryIndex].color}`
    }
  },
  created() {
    axios.get('/Category').then((response) => this.categories = response.data)
  }

}
</script>