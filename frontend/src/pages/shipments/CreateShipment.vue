<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить отгрузку {{ shipment.shipmentId }}</div>

    <TextField name="Целевой Адрес" :vfield="v$.shipment.targetAddress" v-model="shipment.targetAddress"></TextField>
    <DatePicker name="Дата начала отгрузки" :vfield="v$.shipment.shipmentStartDate" v-model="shipment.shipmentStartDate"></DatePicker>
    <DatePicker name="Дата окончания отгрузки" :vfield="v$.shipment.shipmentEndDate" v-model="shipment.shipmentEndDate"></DatePicker>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Контактный телефон</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.contactPhone">
    </div>
    
    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";
import useVuelidate from "@vuelidate/core";
import validators from "@/validators";
import TextField from "@/controls/TextField";
import DatePicker from "@/controls/DatePicker";


export default {
  name: "CreateShipmentPage",
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      shipment: {
        targetAddress: '',
        shipmentStartDate: '',
        shipmentEndDate: '',
        contactPhone: ''
      }
    }
  },
  validations () {
    return {
      shipment: {
        targetAddress: {
          checkLength: validators.checkLength(5, 120),
        },
        shipmentStartDate: {
          checkFullness: validators.checkFullness()
        },
        shipmentEndDate: {
          checkFullness: validators.checkFullness()
        },
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.post(`/Shipment`, this.shipment).then((response) => {
        this.$router.push(`/shipment/${response.data.shipmentId}`)
      })
    }
  },
  components: {
    TextField,
    DatePicker
  }
}
</script>