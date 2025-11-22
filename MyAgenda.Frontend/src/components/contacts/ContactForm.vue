<script setup>
import { ref, watch } from "vue";
import { useContacts } from "../../composables/useContacts";

const props = defineProps({
  contact: {
    type: Object,
    default: null,
  },
});

const emit = defineEmits(["close", "created", "updated"]);

const name = ref("");
const email = ref("");
const phone = ref("");

const { createContact, updateContact } = useContacts();

function formatPhone(value) {
  if (!value) return "";
  const digits = value.replace(/\D/g, "").slice(0, 11);

  if (digits.length <= 2) return `(${digits}`;
  if (digits.length <= 7)
    return `(${digits.slice(0, 2)}) ${digits.slice(2)}`;
  return `(${digits.slice(0, 2)}) ${digits.slice(2, 7)}-${digits.slice(7)}`;
}

function handlePhoneInput(e) {
  phone.value = formatPhone(e.target.value);
}

watch(
  () => props.contact,
  (newVal) => {
    if (newVal) {
      name.value = newVal.name;
      email.value = newVal.email;
      phone.value = formatPhone(newVal.phone); 
    } else {
      name.value = "";
      email.value = "";
      phone.value = "";
    }
  },
  { immediate: true }
);

const handleSubmit = async () => {
  try {
    const rawPhone = phone.value.replace(/\D/g, ""); 

    if (rawPhone.length !== 11) {
      alert("O telefone deve conter 11 dígitos!");
      return;
    }

    const payload = {
      name: name.value,
      email: email.value,
      phone: rawPhone,
    };

    if (props.contact && props.contact.id) {
      await updateContact(props.contact.id, payload);
      emit("updated");
    } else {
      await createContact(payload);
      emit("created");
    }

    emit("close");
  } catch (err) {
    console.error("Erro ao salvar contato:", err);
    alert("Não foi possível salvar o contato. Veja o console para mais detalhes.");
  }
};
</script>

<template>
  <div class="fixed inset-0 flex items-center justify-center z-50 bg-white/10 backdrop-blur-md">
    <div class="bg-white p-6 rounded-lg w-96 shadow-lg">
      <h2 class="text-xl font-semibold mb-4">
        {{ props.contact ? "Editar Contato" : "Novo Contato" }}
      </h2>

      <form @submit.prevent="handleSubmit" class="space-y-4">
        <input
          v-model="name"
          placeholder="Nome completo"
          class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />
        <input
          v-model="email"
          placeholder="Email"
          class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />
        <input
          :value="phone"
          @input="handlePhoneInput"
          placeholder="(xx) xxxxx-xxxx"
          class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          required
        />

        <div class="flex justify-end space-x-2">
          <button
            type="button"
            @click="emit('close')"
            class="px-4 py-2 bg-gray-300 rounded hover:bg-gray-400"
          >
            Cancelar
          </button>
          <button
            type="submit"
            class="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
          >
            {{ props.contact ? "Atualizar" : "Criar" }}
          </button>
        </div>
      </form>
    </div>
  </div>
</template>