\ data_stack.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net) 2015, 2016, 2020.

\ Last modified: 202012062211.
\ See change log at the end of the file.

\ ==============================================================
\ Description {{{1

\ This file provides the Z80 code that manages the data stack. It is
\ adapted from Couplement Forth v0.2.0-dev.30.0+202012062211
\ (http://programandala.net/en.program.couplement_forth).

0 [if] \ XXX TODO Adapt the Z80 assembler code to Forth.

; --------------------------------------------------------------
; License

; Copyright (C) 2015,2016,2020 Marcos Cruz (programandala.net)

; You may do whatever you want with this work, so long as you
; retain all copyright notices, all credit notices, and this
; license in all files of all redistributed copies and derived
; works. There is no warranty.

; --------------------------------------------------------------
; Credits

; Couplement Forth was forked from ForthCoupe
; (http://programandala.net/en.program.forthcoupe.html), an
; abandoned Forth for the SAM Coupé, based on John A. Avis'
; SamForth (http://programandala.net/en.program.samforth.html).


data_stack_limit:
data_stack_max_top:
  ; The data stack grows from bottom (high memory) to top (low memory)
  defs $0100
data_stack_bottom:

init_data_stack:
  ld ix,(sp0)
  ret

push_de:
                      ; T Cycles
  dec ix              ;  10
  ld (ix),d           ;  19
  dec ix              ;  10
  ld (ix),e           ;  19
  ret                 ;  10
                      ; 068 total (68 average with pop_de)

pop_de:
                      ; T Cycles
  ld e,(ix)           ;  19
  inc ix              ;  10
  ld d,(ix)           ;  19
  inc ix              ;  10
  ret                 ;  10
                      ; 068 total (68 average with push_de)

push_hl:
                      ; T Cycles
  dec ix              ;  10
  ld (ix),h           ;  19
  dec ix              ;  10
  ld (ix),l           ;  19
  ret                 ;  10
                      ; 068 total (68 average with pop_hl)

pop_hl:
                      ; T Cycles
  ld l,(ix)           ;  19
  inc ix              ;  10
  ld h,(ix)           ;  19
  inc ix              ;  10
  ret                 ;  10
                      ; 068 total (68 average with push_hl)

push_de_hl:
                      ; T Cycles
  dec ix              ;  10
  ld (ix),d           ;  19
  dec ix              ;  10
  ld (ix),e           ;  19
  dec ix              ;  10
  ld (ix),h           ;  19
  dec ix              ;  10
  ld (ix),l           ;  19
  ret                 ;  10
                      ; 126 total (126 average with pop_de_hl)

pop_hl_de:
                      ; T Cycles
  ld l,(ix)           ;  19
  inc ix              ;  10
  ld h,(ix)           ;  19
  inc ix              ;  10
  ld e,(ix)           ;  19
  inc ix              ;  10
  ld d,(ix)           ;  19
  inc ix              ;  10
  ret                 ;  10
                      ; 126 total (126 average with push_hl_de)

[then]

\ ==============================================================
\ Change log {{{1

\ 2020-12-06: Code copied from Couplement Forth
\ v0.2.0-dev.30.0+202012062153
\ (http://programandala.net/en.program.couplement_forth).
