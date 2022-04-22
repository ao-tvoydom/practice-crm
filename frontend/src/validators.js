import { helpers } from '@vuelidate/validators'

export default {
    checkFullness() {
        return helpers.withMessage(`Поле обязательно`, (value) => helpers.req(value))
    },
    checkLength(min, max) {
        return helpers.withMessage(`Длинна должна быть между ${min} и ${max}`, (value) => {
            value = value.toString()
            return value.length >= min && value.length <= max
        })
    },
    checkNumber() {
        return helpers.withMessage(`Только цифры`, (value) => !helpers.req(value) || !isNaN(value))
    }
}