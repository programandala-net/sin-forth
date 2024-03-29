\ lib/do.fs
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
