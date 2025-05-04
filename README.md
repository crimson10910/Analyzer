Functions:
* Construction of the reverse complementary chain
* Manual selection of context by position in the amplicon.
* Detection of single nucleotide polymorphisms (SNP).
* Reading files in FASTA format.
* Export results to CSV.
* Logging capability (reduces productivity significantly).
Most likely, it works crookedly, but somehow it works. Further plans concern exclusively optimization of the application, modularity, adding multithreading and exception handling. I am not a bioinformatician.

output:
Name	Reads	Position	A_freq	T_freq (ref)	G_freq	C_freq (mut)	Invalid_seq, %	Invalid_seq	Short	Short %	Name	Reads	Position	A_freq	T_freq (ref)	G_freq	C_freq (mut)	Invalid_seq, %	Short	Short %	Discrepancy	Discrepancy, %
![image](https://github.com/user-attachments/assets/f22f985c-3198-43fc-8790-20b743da8447)

Name - name of R1 file
Position - position in sequence 
Invalid_seq - reads with errors
Short - reads shorter than position + left context
Name - name of R2
=//=

Функции: 
* Построение обратно-комплементарной цепи
* Ручной выбор контекста по позиции в ампликоне.
* Детекция однонуклеотидных полиморфизмов (SNP).
* Чтение файлов в формате FASTA.
* Экспорт результатов в CSV.
* Возможность логирования (черезвычайно сильно снижает производителдьность).
Работает криво, скорее всего, но как-то работает. Дальнейшие планы касаются исключительно оптимизации приложения, модульность, добавления многопоточности и отработки исключений. Я не биоинформатик.
