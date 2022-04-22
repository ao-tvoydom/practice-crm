<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Редактировать товар</div>

    <TextField name="Название" :vfield="v$.product.name" v-model="product.name"></TextField>
    <TextField name="Вес" :vfield="v$.product.weight" v-model="product.weight"></TextField>
    <TextField name="Высота" :vfield="v$.product.height" v-model="product.height"></TextField>
    <TextField name="Ширина" :vfield="v$.product.width" v-model="product.width"></TextField>
    <TextField name="Длинна" :vfield="v$.product.length" v-model="product.length"></TextField>

    <div class="form-control w-full">
      <label class="label">
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
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product/${product.productId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";
import useVuelidate from "@vuelidate/core";
import validators from "@/validators";
import TextField from "@/controls/TextField";

export default {
  setup () {
    return { v$: useVuelidate() }
  },
  name: "EditProductPage",
  data() {
    return {
      product: {
        name: '',
        weight: '',
        height: '',
        length: '',
        width: '',
        productId: this.$route.params.id,
        categoryIdArray: []
      },
      categories: {},
      multiselectClasses
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.put(`/Product/${this.product.productId}`, {
        productId: this.product.productId,
        name: this.product.name,
        width: this.product.width,
        height: this.product.height,
        length: this.product.length,
        weight: this.product.weight
      }).then(() => {
        this.$router.push(`/product/${this.product.productId}`)
      })
    }
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
  components: {
    TextField,
    Multiselect
  },
  created() {
    axios.get(`/Product/${this.product.productId}`).then((response) => this.product = response.data)
    axios.get('/Category').then((response) => {
      this.categories = response.data.map((category) => {
        return { value: category.categoryId, label: category.name }
      })
    })
  }
}
</script>

<style scoped>

</style>