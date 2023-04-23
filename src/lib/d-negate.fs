\ lib/d-negate.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl-de.fs  \ `pop-hl-de`
require push-de-hl.fs \ `push-de-hl`

get-order get-current

target-definitions

host{

0 [if]

: dnegate ( d1 -- d2 )

  \ Credit: Code adapted from Solo Forth, previously adapted from
  \ Lennart Benschop's Spectrum Forth-83 (1988).

                \                                             ;; T   B
                \                                             ;; --- --
  pop-hl-de     \ call pop_hl_de                              ;; 019 03
                \ ;  HL = high part, DE = low part            ;; 126
  push-hl       \ call push_hl      ;  save copy              ;; 019 03
                \                                             ;; 068
  $0000 h ldp#, \ ld      hl,$0000                            ;; 010 03
  a and,        \ and     a                                   ;; 004 01
  d sbcp,       \ sbc     hl,de     ;  HL = negated low part  ;; 015 02
  pop-de        \ call pop_de       ;  high part              ;; 019 03
                \                                             ;; 068
  push-hl       \ call push_hl      ;  high part              ;; 019 03
                \                                             ;; 068
                \ push    hl        ;  negated low part       ;; 011 01
  $0000 h ldp#, \ ld      hl,$0000                            ;; 010 03
  d sbcp,       \ sbc     hl,de     ;  HL = negated high part ;; 015 02
  push-hl       \ call push_hl      ;                         ;; 019 03
                \                                             ;; 068
  ;             \ ret                                         ;; 010 01
                \                                             ;; --- --
                \                                             ;; 568 28 Total

[then]

}

: dnegate ( d1 -- d2 )

  \ Credit: Code adapted from Solo Forth, previously adapted from
  \ Abersoft Forth; also found in White Lightning.

                  \                                           ;; T  B
                  \                                           ;; --- --
  pop-hl-de       \ call pop_hl_de                            ;; 019 03
                  \ ; HL = high part, DE = low part           ;; 126

  a sub,          \ sub a       ; zero                        ;; 004 01
  e sub,          \ sub e       ; two's complement to Fc      ;; 004 01
  a e ld,         \ ld e,a                                    ;; 004 01
  $00 a ld#,      \ ld a,$00                                  ;; 007 02
  d sbc,          \ sbc a,d     ; two's complement with carry ;; 004 01
  a d ld,         \ ld d,a                                    ;; 004 01
  $00 a ld,       \ ld a,$00                                  ;; 007 02
  l sbc,          \ sbc a,l     ; two's complement with carry ;; 004 01
  a l ld,         \ ld l,a                                    ;; 004 01
  $00 a ld#,      \ ld a,$00                                  ;; 007 02
  h sbc,          \ sbc a,h     ; two's complement with carry ;; 004 01
  a h ld,         \ ld h,a                                    ;; 004 01
  push-de-hl      \ call push_de_hl                           ;; 019 03
                  \                                           ;; 126
  ;               \ ret                                       ;; 010 01
                  \                                           ;; --- --
                  \                                           ;; 357 22 Total

  \ doc{
  \
  \ dnegate ( d1 -- d2 ) "d-negate"
  \
  \ Negate _d1_, giving its arithmetic inverse _d2_.
  \
  \ See also: `negate`, `?dnegate`.
  \
  \ }doc

  \ NOTE: High level version from Z88 CamelForth:
  \
  \ ----
  \ : dnegate ( d1 -- d2 ) swap invert swap invert 1 m+ ;
  \ ----

set-current set-order
