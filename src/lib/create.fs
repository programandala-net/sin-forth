\ lib/create.fs
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

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: create ( "name" -- )
  creator ,
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ create ( "name" -- )

  \ Parse _name_.  Create  a definition for _name_.  After _name_
  \ is created, the data-space pointer (returned by `here`),
  \ points to the first byte of __name__'s data field.  When
  \ _name_ is subsequently executed, the address of the first byte
  \ of __name__'s data field is left on the stack.
  \
  \ ``create`` does not allocate data space in __name__'s data
  \ field. Reservation of data field space is tipically done with
  \ `allot`.
  \
  \ // XXX TODO
  \ // The execution semantics of _name_ may be expanded by using
  \ // `does>`.
  \
  \ See also: `variable` `,`, `c,`, `2,`.
  \
  \ }doc

set-current set-order
