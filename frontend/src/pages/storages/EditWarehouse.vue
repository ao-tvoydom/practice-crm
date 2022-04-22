<template>
  <div class="card bg-neutral p-4 text-neutral-content w-2/5 m-auto ">
    <div class="text-3xl mb-2">Редактировать склад</div>

    <TextField name="Название" :vfield="v$.warehouse.name" v-model="warehouse.name"></TextField>
    <TextField name="Адрес" :vfield="v$.warehouse.address" v-model="warehouse.address"></TextField>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/warehouse/${warehouse.warehouseId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";
import TextField from "@/controls/TextField";
import useVuelidate from "@vuelidate/core";
import validators from "@/validators";

export default {
  name: "EditStoragePage",
  components: {TextField},
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      warehouse: {
        warehouseId: this.$route.params.id,
        name: "",
        address: "",
      }
    }
  },
  validations () {
    return {
      warehouse: {
        name: {
          checkLength: validators.checkLength(3, 50),
        },
        address: {
          checkLength: validators.checkLength(5, 120),
        }
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.put(`/Warehouse/${this.warehouse.warehouseId}`, this.warehouse).then(() => {
        this.$router.push(`/warehouse/${this.warehouse.warehouseId}`)
      })
    }
  },
  created() {
    axios.get(`/Warehouse/${this.warehouse.warehouseId}`).then((response) => this.warehouse = response.data)
  }
}
</script>

<style scoped>

</style>