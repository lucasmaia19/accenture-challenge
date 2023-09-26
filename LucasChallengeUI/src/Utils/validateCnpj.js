export function validateCnpj(CNPJ) {
    CNPJ = CNPJ.replace(/[^\d]+/g, "");
    const a = [];
    let b = 0;
    const c = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
    for (let i = 0; i < 12; i++) {
      a[i] = parseInt(CNPJ.charAt(i));
      b += a[i] * c[i + 1];
    }
    let x = b % 11;
    if (x < 2) {
      a[12] = 0;
    } else {
      a[12] = 11 - x;
    }
    b = 0;
    for (let y = 0; y < 13; y++) {
      b += a[y] * c[y];
    }
    x = b % 11;
    if (x < 2) {
      a[13] = 0;
    } else {
      a[13] = 11 - x;
    }
    if (CNPJ.charAt(12) !== String(a[12]) || CNPJ.charAt(13) !== String(a[13])) {
      return false;
    }
    if (CNPJ === "00000000000000") {
      return false;
    }
    return true;
  }