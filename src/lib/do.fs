\ lib/do.fs

\ This file is part of Sin Forth.

\ This file adds `do` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

: do ( -- do-sys )
  postpone (do >mark ; immediate compile-only

  \ Credit:
  \ Code adapted from Solo Forth,
  \ originally adapted from Spectrum Forth-83.

  \ doc{
  \
  \ do
  \   Compilation: ( -- do-sys )
  \

  \ Compile `(do` and leave _do-sys_ to be consumed by `loop`
  \ or `+loop`.
  \
  \ ``do`` is an `immediate` and `compile-only` word.
  \
  \ See also: `?do`.
  \
  \ }doc

set-current set-order
