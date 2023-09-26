import axios from 'axios';

export async function validateCep(cep) {
  const path = `https://opencep.com/v1/${cep.replace(/-/g, '')}`;

  try {
    await axios.get(path);
    return true;
  } catch (error) {
    return false;
  }
}