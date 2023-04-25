\ lib/place.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

\ require x.fs \ `x`

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
