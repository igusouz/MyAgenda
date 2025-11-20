<script setup>
import { ref, onMounted } from "vue";
import ContactForm from "../components/contacts/ContactForm.vue";
import ContactList from "../components/contacts/ContactList.vue";
import { getContacts } from "../api/contactsService";

const contacts = ref([]);
const showModal = ref(false);
const selectedContact = ref(null);
const isLoading = ref(false);

const loadContacts = async () => {
  isLoading.value = true;
  try {
    const res = await getContacts();
    contacts.value = res.data;
  } catch (err) {
    console.error("Erro ao carregar contatos:", err);
  } finally {
    isLoading.value = false;
  }
};

const openCreate = () => {
  selectedContact.value = null;
  showModal.value = true;
};

const openEdit = (contact) => {
  selectedContact.value = contact;
  showModal.value = true;
};

onMounted(loadContacts);
</script>

<template>
  <div class="min-h-screen bg-gray-100 p-6">
    <div class="max-w-4xl mx-auto bg-white shadow-lg rounded-lg p-6">

      <!-- Header -->
      <div class="flex justify-between items-center mb-6">
        <h1 class="text-3xl font-bold text-gray-800">📒 MyAgenda</h1>
        <button
          @click="openCreate"
          class="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition"
        >
          Novo Contato
        </button>
      </div>

      <!-- Loading -->
      <div v-if="isLoading" class="text-center py-4 text-gray-500">
        Carregando contatos...
      </div>

      <!-- Lista de contatos -->
      <div class="overflow-y-auto max-h-[70vh] w-full">
        <ContactList
          :contacts="contacts"
          @edit="openEdit"
          @deleted="loadContacts"
        />
      </div>
    </div>

    <!-- Modal de criação/edição -->
    <ContactForm
      v-if="showModal"
      :contact="selectedContact"
      @close="showModal = false"
      @created="loadContacts"
      @updated="loadContacts"
    />
  </div>
</template>