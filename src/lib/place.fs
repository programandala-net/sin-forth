\ lib/place.fs

\ This file is part of Sin Forth.

\ This file adds `place` to the COMPILER/TARGET.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

\ require x.fs \ `x`

get-order get-current

target-definitions

: place ( ca1 len1 ca2 -- )

  \ XXX TODO
  \
  \ exx         ; save Forth IP
  \ pop de      ; DE=ca2
  \ pop bc      ; BC=len1
  \ pop hl      ; HL=ca1
  \ push bc     ; len1
  \ push de     ; ca2
  \ inc  de
  \ call move_block
  \ pop hl      ; ca2
  \ pop de      ; E=len1
  \ ld (hl),e
  \ exx         ; restore Forth IP

  ;

  \ Credit: Code adapted from Solo Forth, previously adapted from
  \ DZX-Forth's `packed`.

  \ doc{
  \
  \ place ( ca1 len1 ca2 -- )
  \
  \ Store the string _ca1 len1_ as a counted string at _ca2_.  The
  \ source and destination strings are permitted to overlap.
  \
  \ ``place`` is written in Z80. Its equivalent definition in
  \ Forth is the following:

  \ ----
  \ : place ( ca1 len1 ca2 -- ) 2dup c! char+ smove ;
  \ ----

  \ See also: `+place`, `smove`.
  \
  \ }doc

set-current set-order
