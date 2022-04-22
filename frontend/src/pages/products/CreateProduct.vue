<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto overflow-visible ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить товар</div>

    <TextField name="Название" :vfield="v$.product.name" v-model="product.name"></TextField>
    <TextField name="Вес" :vfield="v$.product.weight" v-model="product.weight"></TextField>
    <TextField name="Высота" :vfield="v$.product.height" v-model="product.height"></TextField>
    <TextField name="Ширина" :vfield="v$.product.width" v-model="product.width"></TextField>
    <TextField name="Длинна" :vfield="v$.product.length" v-model="product.length"></TextField>

    <div class="form-control w-full">
      <label class="label justify-start">
        <span class="label-text text-neutral-content">Категории</span>
      </label>
      <Multiselect
          v-model="product.categoryIdArray"
          :close-on-select="false"
          :options="categories"
          mode="tags"
          :classes="multiselectClasses"
      />
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>
<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";
import validators from "@/validators";
import useVuelidate from "@vuelidate/core";
import TextField from "@/controls/TextField";

export default {
  name: "CreateProductPage",
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      product: {
        name: '',
        weight: '',
        height: '',
        length: '',
        width: '',
        categoryIdArray: []
      },
      categories: {},
      multiselectClasses
    }
  },
  components: {
    TextField,
    Multiselect
  },
  validations () {
    return {
      product: {
        name: {
          checkLength: validators.checkLength(3, 75)
        },
        weight: {
          checkNumber: validators.checkNumber(),
          checkLength: validators.checkLength(1, 3)
        },
        height: {
          checkNumber: validators.checkNumber(),
          checkLength: validators.checkLength(1, 3)
        },
        width: {
          checkNumber: validators.checkNumber(),
          checkLength: validators.checkLength(1, 3)
        },
        length: {
          checkNumber: validators.checkNumber(),
          checkLength: validators.checkLength(1, 3)
        },
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.post(`/Product`, this.product).then((response) => {
        this.$router.push(`/product/${response.data.productId}`)
      })
    }
  },
  created() {
    axios.get('/Category').then((response) => {
      this.categories = response.data.map((category) => {
        return { value: category.categoryId, label: category.name }
      })
    })
  }
}
</script>

<style src="@vueform/multiselect/themes/default.css"></style>
