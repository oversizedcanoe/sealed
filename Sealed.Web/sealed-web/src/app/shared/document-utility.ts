export async function showToast(message: string) {
    const toast =  document.querySelector('#toast');
    const toastText =  document.querySelector('#toastText');

    if (toast instanceof HTMLElement && toastText instanceof HTMLElement) {
      toastText.innerHTML = message;
      toast.style.opacity = '1';

      setTimeout(()=>{
        toast.style.opacity = '0'
      },2000);

      setTimeout(() => {
        toastText.innerHTML = '';
      }, 2200)
    }
  }